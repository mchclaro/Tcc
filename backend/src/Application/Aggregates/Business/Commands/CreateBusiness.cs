using Domain.Enums;
using Application.Result;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;
using Domain.Entities;
using Domain.Utils;
using Domain.Interfaces.Services;

namespace Application.Aggregates.Business.Commands
{
    public class CreateBusiness
    {
        public class Command : IRequest<StandardResult<object>>
        {
            public string CNPJ { get; set; }
            public string SocialReson { get; set; }
            public string FantasyName { get; set; }
            public string BusinessName { get; set; }
            public Priority Priority { get; set; }
            public Category Category { get; set; }
            public string Zipcode { get; set; }
            public string AddressStreet { get; set; }
            public string AddressStreetNumber { get; set; }
            public string AddressDistrict { get; set; }
            public string AddressState { get; set; }
            public string AddressComplement { get; set; }
            public string AddressCity { get; set; }
            public string Latitude { get; set; }
            public string Longitude { get; set; }
            public IFormFile MainImage { get; set; }
            public string Phone { get; set; }
            public string Whatsapp { get; set; }
            public string Instagram { get; set; }
            public string Facebook { get; set; }
            public string OpeningHours { get; set; }
        }
        public class Handler : IRequestHandler<Command, StandardResult<object>>
        {
            private readonly IBusinessRepository _businessRepository;
            private readonly IAddressRepository _addressRepository;
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IOpeningHoursRepository _openingHoursRepository;
            private readonly IConfiguration _configuration;
            private readonly IMapper _mapper;
            private readonly IFileStorageServiceS3 _fileStorage;
            private readonly string bucket;

            public Handler(IBusinessRepository businessRepository,
                           IAddressRepository addressRepository,
                           ISocialMediaRepository socialMediaRepository,
                           IOpeningHoursRepository openingHoursRepository,
                           IConfiguration configuration,
                           IFileStorageServiceS3 fileStorage,
                           IMapper mapper)
            {
                _fileStorage = fileStorage;
                _businessRepository = businessRepository;
                _addressRepository = addressRepository;
                _socialMediaRepository = socialMediaRepository;
                _openingHoursRepository = openingHoursRepository;
                _configuration = configuration;
                _mapper = mapper;
                bucket = "havetrade-photos";
            }
            public async Task<StandardResult<object>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<object> { };
                string mainImage = "";

                try
                {
                    if (request.CNPJ == null)
                    {
                        result.AddError(Code.BadRequest, "Não foi possível continuar o cadastro pois o CNPJ é inválidos.");
                        return result.GetResult();
                    }

                    if (await _businessRepository.IsCnpjInUse(request.CNPJ))
                    {
                        result.AddError(Code.BadRequest, "Já existe uma conta associada ao CNPJ informado.");
                        return result.GetResult();
                    }

                    request.CNPJ = ValidationHelper.RemoveDirtCharsForCnpj(request.CNPJ);

                    if (string.IsNullOrEmpty(request.SocialReson))
                    {
                        result.AddError(Code.BadRequest, "O razão social não pode ser vazia.");
                        return result.GetResult();
                    }
                    if (string.IsNullOrEmpty(request.FantasyName))
                    {
                        result.AddError(Code.BadRequest, "O nome fantasia não pode ser vazio.");
                        return result.GetResult();
                    }
                    if (string.IsNullOrEmpty(request.BusinessName))
                    {
                        result.AddError(Code.BadRequest, "O nome do comércio não pode ser vazio.");
                        return result.GetResult();
                    }

                    if (request.MainImage == null)
                    {
                        string invalidImage = "Foto não encontrada";
                        result.AddError(Code.BadRequest, invalidImage);
                        return result.GetResult();
                    }

                    var entity = _mapper.Map<Command, Domain.Entities.Business>(request);
                   
                    //upload de foto com s3
                    if (request.MainImage != null)
                    {
                        string photoUuid = Guid.NewGuid().ToString("N");
                        string objectName = $"business_photo_{photoUuid}{Path.GetExtension(request.MainImage.FileName)}";
                        await _fileStorage.UploadFileFromHttpIFormFile(bucket, objectName, request.MainImage);
                        mainImage = _fileStorage.GetFileUrlS3(objectName);

                        if (!string.IsNullOrEmpty(entity.MainImage) && entity.MainImage != mainImage)
                        {
                            await _fileStorage.DeleteFileFromUrlS3(entity.MainImage);
                        }
                    }

                    if (!string.IsNullOrEmpty(mainImage))
                        entity.MainImage = mainImage;

                    entity.AddressId = await saveAddress(request);
                    entity.SocialMediaId = await saveSocialMedia(request);

                    var businessId = await _businessRepository.Create(entity);

                    await generateOpeningHours(request, businessId);

                }
                catch (Exception)
                {
                    result.AddError(Code.GenericError, "Erro ao cadastrar o comércio");
                }

                return result.GetResult();
            }

            private async Task<int> saveAddress(Command request)
            {
                var address = new Address
                {
                    Street = request.AddressStreet,
                    StreetNumber = request.AddressStreetNumber,
                    Complement = request.AddressComplement,
                    District = request.AddressDistrict,
                    ZipCode = ValidationHelper.RemoveDirtCharsForCep(request.Zipcode),
                    State = request.AddressState,
                    City = request.AddressCity,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude
                };

                return await _addressRepository.Create(address);
            }

            public async Task<int> saveSocialMedia(Command request)
            {
                var facebook = "https://www.facebook.com/";
                var instagram = "https://www.instagram.com/";
                var prefixo = "+55";
                var wpp = "wa.me/+55";

                var socialMedia = new SocialMedia
                {
                    Phone = prefixo + request.Phone,
                    Whatsapp = wpp + request.Whatsapp,
                    Instagram = instagram + request.Instagram,
                    Facebook = facebook + request.Facebook
                };

                return await _socialMediaRepository.Create(socialMedia);
                
            }

            public async Task generateOpeningHours(Command request, int businessId)
            {
                var openingHoursList = OpeningHoursHelper.ParseManyTimeTables(request.OpeningHours);
                foreach (var openingHours in openingHoursList)
                {
                    openingHours.BusinessId = businessId;

                    await _openingHoursRepository.Create(openingHours);
                }
            }

            // private async Task<(bool, string)> updateBusinessMainImage(Command request)
            // {
            //     string mainImage = string.Empty;
            //     bool fileSizeExceeded = false;

            //     if (request.MainImage is null)
            //         return (fileSizeExceeded, mainImage);

            //     if (!FileSizeValidationHelper.IsFileSizeAllowed(_configuration, request.MainImage.Length))
            //     {
            //         fileSizeExceeded = true;
            //         mainImage = "O tamanho da foto excede o limite permitido. Selecione uma foto que possua no máximo 8MB de tamanho.";

            //         return (fileSizeExceeded, mainImage);
            //     }

            //     string mainImageUuid = Guid.NewGuid().ToString("N");

            //     string objectName = $"business_photo_{mainImageUuid}{Path.GetExtension(request.MainImage.FileName)}";

            //     await _fileStorage.UploadFileFromHttpIFormFile(request.MainImage, _imageBucket, objectName);

            //     mainImage = _fileStorage.GetFileUrl(_imageBucket, objectName);

            //     return (fileSizeExceeded, mainImage);
            // }
        }
    }
}
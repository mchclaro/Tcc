using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO.Business;
using Domain.Entities;
using Newtonsoft.Json.Linq;

namespace Domain.Utils
{
    public class OpeningHoursHelper
    {
        public static IEnumerable<OpeningHours> ParseManyTimeTables(string jsonList)
        {
            JArray timtableJson = JArray.Parse(jsonList);

            var dtoList = timtableJson.ToObject<OpeningHoursDTO[]>();

            return dtoList
                .Select(dto => new OpeningHours
                {
                    BusinessId= dto.BusinessId,
                    Start = dto.Start,
                    End = dto.End,
                    Break = dto.Break,
                    DayOfWeek = dto.DayOfWeek,
                })
                .ToList();
        }
    }
}
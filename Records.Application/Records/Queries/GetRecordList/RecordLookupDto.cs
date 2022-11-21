using AutoMapper;
using System;
using Records.Application.Common.Mappings;
using Records.Domain;

namespace Records.Application.Records.Queries.GetRecordList
{
    public class RecordLookupDto : IMapWith<Record>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Record, RecordLookupDto>()
                .ForMember(recordDto => recordDto.Id,
                    opt => opt.MapFrom(record => record.Id))
                .ForMember(recordDto => recordDto.Title,
                    opt => opt.MapFrom(record => record.Title));
        }
    }
}

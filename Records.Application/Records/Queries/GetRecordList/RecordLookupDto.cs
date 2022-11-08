using System;
using AutoMapper;
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
                .ForMember(noteDto => noteDto.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(noteDto => noteDto.Title,
                    opt => opt.MapFrom(note => note.Title));
        }
    }
}

using System;
using AutoMapper;
using Records.Application.Common.Mappings;
using Records.Domain;

namespace Records.Application.Records.Queries.GetRecordDetails
{
    public class RecordDetailsVm : IMapWith<Record>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Record, RecordDetailsVm>()
                .ForMember(recordVm => recordVm.Title,
                    opt => opt.MapFrom(record => record.Title))
                .ForMember(recordVm => recordVm.Details,
                    opt => opt.MapFrom(record => record.Details))
                .ForMember(recordVm => recordVm.Id,
                    opt => opt.MapFrom(record => record.Id))
                .ForMember(recordVm => recordVm.CreationDate,
                    opt => opt.MapFrom(record => record.CreationDate))
                .ForMember(recordVm => recordVm.EditDate,
                    opt => opt.MapFrom(record => record.EditDate));
        }
    }
}

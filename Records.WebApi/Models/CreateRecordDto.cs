using AutoMapper;
using System;
using Records.Application.Common.Mappings;
using Records.Application.Records.Commands.CreateRecord;

namespace Records.WebApi.Models
{
    public class CreateRecordDto : IMapWith<CreateRecordCommand>
    {
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateRecordDto, CreateRecordCommand>()
                .ForMember(recordCommand => recordCommand.Title,
                    opt => opt.MapFrom(recordDto => recordDto.Title))
                .ForMember(recordCommand => recordCommand.Details,
                    opt => opt.MapFrom(recordDto => recordDto.Details));
        }
    }
}
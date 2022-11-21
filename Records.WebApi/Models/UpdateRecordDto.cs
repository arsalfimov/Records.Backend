using AutoMapper;
using System;
using Records.Application.Common.Mappings;
using Records.Application.Records.Commands.UpdateRecord;

namespace Records.WebApi.Models
{
    public class UpdateRecordDto : IMapWith<UpdateRecordCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateRecordDto, UpdateRecordCommand>()
                .ForMember(recordCommand => recordCommand.Id,
                    opt => opt.MapFrom(recordDto => recordDto.Id))
                .ForMember(recordCommand => recordCommand.Title,
                    opt => opt.MapFrom(recordDto => recordDto.Title))
                .ForMember(recordCommand => recordCommand.Details,
                    opt => opt.MapFrom(recordDto => recordDto.Details));
        }
    }
}
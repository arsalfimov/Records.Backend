using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Records.Application.Records.Queries.GetRecordList;
using Records.Application.Records.Queries.GetRecordDetails;
using Records.Application.Records.Commands.CreateRecord;
using Records.Application.Records.Commands.UpdateRecord;
using Records.Application.Records.Commands.DeleteCommand;
using System;
using Records.WebApi.Models;

namespace Records.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RecordController : BaseController
    {
        private readonly IMapper _mapper;
        
        public RecordController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<RecordListVm>> GetAll()
        {
            var query = new GetRecordListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet]
        public async Task<ActionResult<RecordDetailsVm>> Get(Guid id)
        {
            var query = new GetRecordDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateRecordDto createRecordDto)
        {
            var command = _mapper.Map<CreateRecordCommand>(createRecordDto);
            command.UserId = UserId;
            var recordId = await Mediator.Send(command);
            return Ok(recordId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRecordDto updateRecordDto)
        {
            var command = _mapper.Map<UpdateRecordCommand>(updateRecordDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteRecordCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }


    }
}

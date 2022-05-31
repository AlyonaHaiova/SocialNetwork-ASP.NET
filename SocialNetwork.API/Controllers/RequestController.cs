using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using SocialNetwork.Models.Dto;
using SocialNetwork.Services.Abstract;
using SocialNetwork.Services.Impl;
using System.Collections.Generic;

namespace SocialNetwork.API.Controllers
{
    [Route("api/users/{id}/requests")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService requestService;

        public RequestController()
        {
            requestService = new RequestService();
        }

        [HttpGet("received")]
        public List<Relationship> GetRequestsToUser([FromRoute] int id)
        {
            return requestService.GetRequestsToUser(id);
        }

        [HttpGet("sent")]
        public List<Relationship> GetRequestsFromUser([FromRoute] int id)
        {
            return requestService.GetRequestsFromUser(id);
        }

        [HttpPut("{relationshipId}/accept")]
        public int AcceptRequest([FromRoute] int relationshipId)
        {
            return requestService.AcceptRequest(relationshipId);
        }

        [HttpPut("{relationshipId}/decline")]
        public int DeclineRequest([FromRoute] int relationshipId)
        {
            return requestService.DeclineRequest(relationshipId);
        }

        [HttpDelete("sent/{relationshipId}")]
        public void CancelRequest([FromRoute] int relationshipId)
        {
            requestService.CancelUsersRequest(relationshipId);
        }
    }
}

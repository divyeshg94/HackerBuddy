using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerBuddy.Sql.Models;

namespace HackerBuddy.Sql.Interface
{
    public interface ITeamupRequestService
    {
        Task<IEnumerable<TeamupRequest>> GetRequestsForPerson(int personId);
        Task<IEnumerable<TeamupRequest>> GetSentRequests(int personId);
        Task<TeamupRequest> SendTeamupRequest(int requesterId, int receiverId);
        Task<TeamupRequest> UpdateRequestStatus(int requestId, string status);
    }
}

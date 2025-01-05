using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerBuddy.Sql.Interface;
using HackerBuddy.Sql.Models;
using Microsoft.EntityFrameworkCore;

namespace HackerBuddy.Sql.Service
{
    public class TeamupRequestService : ITeamupRequestService
    {
        private readonly ApplicationDbContext _context;

        public TeamupRequestService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get received requests for the person
        public async Task<IEnumerable<TeamupRequest>> GetRequestsForPerson(int personId)
        {
            return await _context.TeamupRequests
                .Where(r => r.ReceiverID == personId && r.Status == "Pending")
                .Include(r => r.Requester) // Eager load requester details
                .ToListAsync();
        }

        // Get sent requests by the person
        public async Task<IEnumerable<TeamupRequest>> GetSentRequests(int personId)
        {
            return await _context.TeamupRequests
                .Where(r => r.RequesterID == personId && r.Status == "Pending")
                .Include(r => r.Receiver) // Eager load receiver details
                .ToListAsync();
        }

        public async Task<TeamupRequest> SendTeamupRequest(int requesterId, int receiverId)
        {
            var request = new TeamupRequest
            {
                RequesterID = requesterId,
                ReceiverID = receiverId
            };

            _context.TeamupRequests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<TeamupRequest> UpdateRequestStatus(int requestId, string status)
        {
            var request = await _context.TeamupRequests.FindAsync(requestId);
            if (request == null) return null;

            request.Status = status;
            await _context.SaveChangesAsync();
            return request;
        }
    }
}

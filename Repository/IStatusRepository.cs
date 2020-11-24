using Storage5.Models;
using System;
using System.Collections.Generic;

namespace Storage5.Repository
{
    public interface IStatusRepository : IDisposable
    {
        IEnumerable<Status> GetAllStatuses();

        Status GetStatusByID(int StatusId);

        void UpdateStatus(Status status);

        void SaveChanges();

        void RemoveStatus(int StatusId);

        void AddStatus(Status status);
    }
}

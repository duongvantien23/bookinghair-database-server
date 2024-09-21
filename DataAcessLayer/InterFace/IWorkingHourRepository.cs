using DataModel;
using System;
using System.Collections.Generic;

namespace DataAcessLayer.InterFace
{
    public interface IWorkingHourRepository
    {
        bool Create(WorkingHourModel workingHour);
        bool Update(WorkingHourModel workingHour);
        bool Delete(int workingHourId);
        WorkingHourModel GetById(int workingHourId);
        List<WorkingHourModel> GetByHairstylist(int hairstylistId);
        List<WorkingHourModel> GetByDate(DateTime workDay);
        bool CheckAvailability(int hairstylistId, DateTime workDay, TimeSpan startTime, TimeSpan endTime);
    }
}

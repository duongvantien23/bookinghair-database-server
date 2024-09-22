using DataModel;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public partial interface IWorkingHourBusiness
    {
        bool CreateWorkingHour(WorkingHourModel workingHour);
        bool UpdateWorkingHour(WorkingHourModel workingHour);
        bool DeleteWorkingHour(int workingHourId);
        WorkingHourModel GetWorkingHourById(int workingHourId);
        List<WorkingHourModel> GetWorkingHoursByHairstylist(int hairstylistId);
        List<WorkingHourModel> GetWorkingHoursByDate(DateTime workDay);
        bool CheckAvailability(int hairstylistId, DateTime workDay, TimeSpan startTime, TimeSpan endTime);
    }
}

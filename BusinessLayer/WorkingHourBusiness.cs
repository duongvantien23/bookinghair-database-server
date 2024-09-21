using BusinessLayer.Interface;
using DataAcessLayer.InterFace;
using DataModel;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class WorkingHourBusiness : IWorkingHourBusiness
    {
        private readonly IWorkingHourRepository _workingHourRepository;

        public WorkingHourBusiness(IWorkingHourRepository workingHourRepository)
        {
            _workingHourRepository = workingHourRepository;
        }

        public bool CreateWorkingHour(WorkingHourModel workingHour)
        {
            return _workingHourRepository.Create(workingHour);
        }

        public bool UpdateWorkingHour(WorkingHourModel workingHour)
        {
            return _workingHourRepository.Update(workingHour);
        }

        public bool DeleteWorkingHour(int workingHourId)
        {
            return _workingHourRepository.Delete(workingHourId);
        }

        public WorkingHourModel GetWorkingHourById(int workingHourId)
        {
            return _workingHourRepository.GetById(workingHourId);
        }

        public List<WorkingHourModel> GetWorkingHoursByHairstylist(int hairstylistId)
        {
            return _workingHourRepository.GetByHairstylist(hairstylistId);
        }

        public List<WorkingHourModel> GetWorkingHoursByDate(DateTime workDay)
        {
            return _workingHourRepository.GetByDate(workDay);
        }

        public bool CheckAvailability(int hairstylistId, DateTime workDay, TimeSpan startTime, TimeSpan endTime)
        {
            return _workingHourRepository.CheckAvailability(hairstylistId, workDay, startTime, endTime);
        }
    }
}

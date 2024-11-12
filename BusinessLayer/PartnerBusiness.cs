using BusinessLayer.Interface; 
using DataAcessLayer.InterFace;
using DataModel;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class PartnerBusiness : IPartnerBusiness
    {
        private readonly IPartnerRepository _partnerRepository;

        public PartnerBusiness(IPartnerRepository partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        public bool CreatePartner(PartnerModel partner)
        {
            return _partnerRepository.Create(partner);
        }

        public bool UpdatePartner(PartnerModel partner)
        {
            return _partnerRepository.Update(partner);
        }

        public bool DeletePartner(int partnerId)
        {
            return _partnerRepository.Delete(partnerId);
        }

        public List<PartnerModel> GetAllPartners()
        {
            return _partnerRepository.GetAll();
        }

        public PartnerModel GetPartnerById(int partnerId)
        {
            return _partnerRepository.GetById(partnerId);
        }
    }
}

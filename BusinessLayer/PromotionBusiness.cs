using BusinessLayer.Interface;
using DataAcessLayer.InterFace;
using DataModel;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class PromotionBusiness : IPromotionBusiness
    {
        private readonly IPromotionRepository _promotionRepository;

        public PromotionBusiness(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public bool CreatePromotion(PromotionModel promotion)
        {
            return _promotionRepository.Create(promotion);
        }

        public bool UpdatePromotion(PromotionModel promotion)
        {
            return _promotionRepository.Update(promotion);
        }

        public bool DeletePromotion(int promotionId)
        {
            return _promotionRepository.Delete(promotionId);
        }

        public List<PromotionModel> GetAllPromotions()
        {
            return _promotionRepository.GetAll();
        }

        public PromotionModel GetPromotionById(int promotionId)
        {
            return _promotionRepository.GetById(promotionId);
        }
    }
}

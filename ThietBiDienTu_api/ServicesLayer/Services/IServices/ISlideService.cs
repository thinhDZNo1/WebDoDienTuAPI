using DTOlayer.Collections.Slide;
using System.Collections.Generic;

namespace ServicesLayer.Services.IServices
{
    public interface ISlideService
    {
        List<SlideToGet> GetAll();
        SlideToGet GetSlide(int id);
        void InsertSlide(SlideToAdd slide);
        void UpdateSlide(SlideToUpdate slide);
        void DeleteSlide(int id);
    }
}

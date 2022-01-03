using DTOlayer.Collections.Color;
using System.Collections.Generic;

namespace ServicesLayer.Services.IServices
{
    public interface IColorService
    {
        List<ColorToGet> GetAll();
        ColorToGet GetColor(int id);
        void InsertColor(ColorToAdd color);
        void UpdateColor(ColorToUpdate color);
        void DeleteColor(int id);
    }
}

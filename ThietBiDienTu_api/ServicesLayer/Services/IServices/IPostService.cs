using DTOlayer.Collections.Post;
using System.Collections.Generic;

namespace ServicesLayer.Services.IServices
{
    public interface IPostService
    {
        List<PostToGet> GetAll();
        PostToGet GetPost(int id);
        void InsertPost(PostToAdd post);
        void UpdatePost(PostToUpdate post);
        void DeletePost(int id);
    }
}

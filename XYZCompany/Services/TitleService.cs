using XYZCompany.Entities;
using XYZCompany.Repositories;
using XYZCompany.Requests;
using XYZCompany.Responses;

namespace XYZCompany.Services
{
    public class TitleService
    {
        private readonly TitleRepository _titleRepository;
        public TitleService(TitleRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }

        public async Task<TitleResponse> Get(Guid id)
        {
            var title =  await _titleRepository.Get(id);

            var response = new TitleResponse
            {
                Id = title.id,
                Description = title.Description
            };
            return response;
        }

        public async Task<List<TitleResponse>> GetAll()
        {
            var titles = await _titleRepository.GetAll();

            var response = titles.Select(title => new TitleResponse
            { 
                Id = title.id,
                Description = title.Description 
            }).ToList();

            return response;
        }

        public async Task<TitleResponse> Create(TitleRequest request)
        {
            if(string.IsNullOrEmpty(request.Description))
            {
                throw new Exception("Description cannot be empty.");
            }

            var title = new Title
            {
                Description = request.Description
            };

            await _titleRepository.Create(title);

            return new TitleResponse
            {
                Id = title.id,
                Description = title.Description
            };
        }

        public async Task<TitleResponse> Update(Guid id, TitleRequest request)
        {
            var title = await _titleRepository.Get(id);

            title.Description = request.Description;

            await _titleRepository.Update(title);

            return new TitleResponse
            {
                Id = title.id,
                Description = title.Description
            };
        }

        public async Task Delete(Guid id)
        {
            await _titleRepository.Delete(id);
        }
    }
}

using CollegeMath.Application.DTO;
using CollegeMath.Application.Interfaces;
using CollegeMath.Domain.Entities;
using CollegeMath.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Application.Applications
{
    public class ContentApplication : IContentApplication
    {
        IContentRepository _contentRepository;

        public ContentApplication(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public IEnumerable<ContentDTO> GetAll()
        {
            return _contentRepository.GetAll().Select(c=> new ContentDTO 
            {
                CreatedDate = c.CreatedDate,
                Description = c.Description,   
                Id = c.Id,
                IsDeleted = c.IsDeleted,
                Name = c.Name
            });
        }

        public void Insert(ContentDTO contentDTO)
        {
            var content = new Content(contentDTO.Name)
            {
                CreatedDate = DateTime.Now,
                Description = contentDTO.Description,
                IsDeleted = false,
            };

            _contentRepository.Insert(content);
        }

        public void Update(ContentDTO contentDTO)
        {
            var content = _contentRepository.Find(contentDTO.Id);
            content.Description = contentDTO.Description;
            content.Name = contentDTO.Name;
            _contentRepository.Update(content);
        }
    }
}

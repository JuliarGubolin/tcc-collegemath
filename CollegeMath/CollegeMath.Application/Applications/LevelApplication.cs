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
    public class LevelApplication : ILevelApplication
    {
        ILevelRepository _levelRepository;

        public LevelApplication(ILevelRepository levelRepository)
        {
            _levelRepository = levelRepository;
        }
        public IEnumerable<LevelDTO> GetAll()
        {
            return _levelRepository.GetAll().Select(c => new LevelDTO
            {
                CreatedDate = c.CreatedDate,
                Description = c.Description,
                Id = c.Id,
                IsDeleted = c.IsDeleted,
                Name = c.Name
            });
        }

        public void Insert(LevelDTO levelDTO)
        {
            var level = new Level(levelDTO.Name)
            {
                CreatedDate = DateTime.Now,
                Description = levelDTO.Description,
                IsDeleted = false,
            };

            _levelRepository.Insert(level);
        }

        public void Update(LevelDTO levelDTO)
        {
            var level = _levelRepository.Find(levelDTO.Id);
            level.Description = levelDTO.Description;
            level.Name = levelDTO.Name;
            _levelRepository.Update(level);
        }
    }
}

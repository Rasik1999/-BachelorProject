using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WorkingWithProjects.API.Models;
using WorkingWithProjects.API.Services;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        private readonly IProgressRepository _progressRepository;
        private readonly INotificationService _notificationService;

        public ProgressController(IProgressRepository progressRepository, INotificationService notificationService)
        {
            _progressRepository = progressRepository;
            _notificationService = notificationService;
        }

        // GET: api/<ProgressController>
        [HttpGet]
        public IEnumerable<Progress> Get()
        {
            return _progressRepository.GetAllProgress();
        }

        // GET api/<ProgressController>/5
        [HttpGet("{id}")]
        public Progress Get(int id)
        {
            return _progressRepository.GetProgressById(id);
        }

        // GET api/<ProgressController>/ByProjectId5
        [HttpGet("byprojectid/{id}")]
        public Progress GetByProjectId(int id)
        {
            return _progressRepository.GetProgressByProjectId(id);
        }

        // GET api/<ProgressController>/5
        [HttpPut("projectId")]
        public Progress Put(int projectId, [FromBody] decimal value)
        {
            var progress = _progressRepository.GetProgressByProjectId(projectId);
            progress.Value += value;

            UpdatePercentage(progress);

            if (progress.PercentageOfCompletion >= 100)
            {
                _notificationService.NotificateAboutProgress(progress);
            }

            return _progressRepository.UpdateProgress(progress);
        }

        // Delete api/<ProgressController>/5
        [HttpDelete("projectId")]
        public Progress Delete(int progressId)
        {
            return _progressRepository.DeletePogress(progressId);
        }

        private void UpdatePercentage(Progress progress)
        {
            progress.PercentageOfCompletion = Math.Round(progress.Value / progress.DesiredValue * 100, 2);
        }
    }
}

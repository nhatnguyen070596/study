using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using study.Repositories.Interface;
using study.Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace study.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService teamService;

        public TeamController(ITeamService service)
        {
            this.teamService = service;
        }

        [HttpGet("GetTeams")]
        public async Task<IActionResult> GetTeams()
        {
            try
            {
                //var cachedTeamData = await redisCache.GetCacheData<List<Team>>("teams");

                //if (cachedTeamData != null)
                //{
                //    return Ok(cachedTeamData);
                //}
                var teams = await this.teamService.GetAllTeams();

                //await redisCache.SetCacheData("teams", teams, DateTimeOffset.Now.AddMinutes(5.0));

                //await redisCache.RemoveData("teams");

                return Ok(teams);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetTeamById/{teamId}")]
        public async Task<IActionResult> GetTeamById(int teamId)
        {
            try
            {
                var teams = await this.teamService.GetTeamById(teamId);
                return Ok(teams);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost("AddTeam")]
        public async Task<IActionResult> AddTeam(Team newTeam)
        {
            try
            {
                var teams = await this.teamService.AddTeam(newTeam);
                return Ok(teams);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPut("EditTeam")]
        public async Task<IActionResult> EditTeam(Team team)
        {
            try
            {
                var rowsAffected = await this.teamService.EditTeam(team);
                return Ok(rowsAffected);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpDelete("DeleteTeam/{teamId}")]
        public async Task<IActionResult> DeleteTeam(int teamId)
        {
            try
            {
                var rowsAffected = await this.teamService.DeleteTeam(teamId);
                return Ok(rowsAffected);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}

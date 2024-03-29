﻿using DataAccess.TeamRepository.Mappers;
using Entities.DbModels;
using FluentAssertions;

namespace DataAccessTests.UnitTests.Mappers;

[TestClass]
public class DbTeamsToTeamsMapperUnitTests
{
    private const string locationNameBase = "Toronto ";
    private const string logoUriBase = "http://";
    private const string teamNameBase = "Maple ";
    public List<DbTeam> DbTeamsFactory(int numberOfTeams)
    {
        var teamList = new List<DbTeam>();
        for (int i = 0; i < numberOfTeams; i++)
        {
            var team = new DbTeam()
            {
                id = i,
                locationName = locationNameBase + i.ToString(),
                logoUri = logoUriBase + i.ToString(),
                teamName = teamNameBase + i.ToString(),
            };
            teamList.Add(team);
        }
        return teamList;
    }
    [TestMethod]
    public void ACallToMap_WithNoDbTeams_ShouldGetNoTeams()
    {
        var dbTeams = new List<DbTeam>();
        var teams = DbTeamsToTeamStatsMapper.Map(dbTeams);

        teams.Should().HaveCount(0);
    }
    [TestMethod]
    public void ACallToMap_WithSevenDbTeams_ShouldGetSevenTeams()
    {
        var dbTeams = DbTeamsFactory(7);
        var teams = DbTeamsToTeamStatsMapper.Map(dbTeams);

        teams.Should().HaveCount(7);
    }
    [TestMethod]
    public void ACallToMap_WithThreeFilledDbTeams_ShouldGetThreeCorrectlyFilledTeams()
    {
        var dbTeams = DbTeamsFactory(15);

        var teams = DbTeamsToTeamStatsMapper.Map(dbTeams).ToList();

        for(int i =0; i < 15; i++)
        {
            var idStr = i.ToString();
            teams[i].team.id.Should().Be(i);
            teams[i].team.teamName.Should().Be(teamNameBase + idStr);
            teams[i].team.locationName.Should().Be(locationNameBase + idStr);
            teams[i].team.logoUri.Should().Be(logoUriBase + idStr);
        }
    }
}

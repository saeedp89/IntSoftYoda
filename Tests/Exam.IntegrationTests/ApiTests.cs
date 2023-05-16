using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Exam.API.Controllers;
using Exam.Application;
using Exam.Repositories;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace Exam.IntegrationTests;

public class ApiTests
{
    [Fact]
    public async Task WhenCreatingUser_NumberOfUsersShouldIncrease()
    {
        var factory = new WebApplicationFactory<Exam.API.Program>();
        var httpClient = factory.CreateDefaultClient();

        await DropAndRecreateDatabase(factory);

        var numberOfUsersBeforeAdd = await GetNumberOfUsers(httpClient);
        // first we make sure there are NONE
        Assert.Equal(0, numberOfUsersBeforeAdd);

        await AddUser(httpClient);

        var numberOfUsersAfterAdd = await GetNumberOfUsers(httpClient);
        // After adding a user, it's just one of us.
        Assert.Equal(1, numberOfUsersAfterAdd);
    }

    [Fact]
    public async Task ShouldGetUserById()
    {
        var factory = new WebApplicationFactory<Exam.API.Program>();
        var httpClient = factory.CreateDefaultClient();

        await DropAndRecreateDatabase(factory);

        var numberOfUsersBeforeAdd = await GetNumberOfUsers(httpClient);
        // first we make sure there are NONE
        Assert.Equal(0, numberOfUsersBeforeAdd);
        await AddUser(httpClient);
        // after adding the first user, we can retrieve by Id==1
        var apiResult = await GetUser(httpClient, "/api/User/1");
        var userDto = JsonConvert.DeserializeObject<UserDto>(
            Convert.ToString(apiResult.Body));
        Assert.Equal("test_firstname", userDto.FirstName);
    }


    private static async Task DropAndRecreateDatabase(WebApplicationFactory<Exam.API.Program> factory)
    {
        using var scope = factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ExamDbContext>();
        await dbContext.Database.EnsureDeletedAsync();
        await dbContext.Database.EnsureCreatedAsync();
    }

    private static async Task AddUser(HttpClient httpClient)
    {
        using HttpResponseMessage responseMessage = await httpClient
            .PostAsJsonAsync("/api/User", new UserDto()
            {
                FirstName = "test_firstname",
                LastName = "test_lastName",
                NationalCode = "0123456789",
                PhoneNumber = "+989123456789"
            });
        responseMessage.EnsureSuccessStatusCode();
    }

    private static async Task<int> GetNumberOfUsers(HttpClient httpClient)
    {
        var response = await httpClient.GetAsync("/api/User");
        var stringResult = await response.Content.ReadAsStringAsync();
        var responseBody = JsonConvert.DeserializeObject<ApiResult>(stringResult);

        return Convert.ToInt32(responseBody.Body);
    }

    private static async Task<ApiResult> GetUser(HttpClient client, string url)
    {
        var httpResponse = await client.GetAsync(url);
        var content = await httpResponse.Content.ReadAsStringAsync();
        var apiResult = JsonConvert.DeserializeObject<ApiResult>(content);
        return apiResult;
    }
}
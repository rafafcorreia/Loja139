using Models;
using Newtonsoft.Json;
using RestSharp;

public class PetTest
{
    private String BASE_URL = "https://petstore.swagger.io/v2/";

    [Test, Order(1)]
    public void PostPetTest()
    {
        var client = new RestClient(BASE_URL);
        var request = new RestRequest("pet", Method.Post);

        String jsonBody = File.ReadAllText("C:/testspace/Loja139/fixtures/pet.json");
        request.AddBody(jsonBody);

        var response = client.Execute(request);
        var responseBody = JsonConvert.DeserializeObject<dynamic>(response.Content);

        Assert.That(((int)response.StatusCode), Is.EqualTo(200));

        String status = responseBody.status.ToString();
        Assert.That(status, Is.EqualTo("available"));
    }

    [Test, Order(2)]
    public void GetPetTest()
    {
        int petId = 9102023;
        String petName = "Spike";

        var client = new RestClient(BASE_URL);
        var request = new RestRequest($"pet/{petId}", Method.Get);
        var response = client.Execute(request);
        var responseBody = JsonConvert.DeserializeObject<dynamic>(response.Content);

        Assert.That((int)response.StatusCode, Is.EqualTo(200));
        Assert.That((int)responseBody.id, Is.EqualTo(petId));
        Assert.That(responseBody.name.ToString(), Is.EqualTo(petName));
        Assert.That((int)responseBody.category.id, Is.EqualTo(0));
        Assert.That((int)responseBody.tags[0].id, Is.EqualTo(0));
        Assert.That(responseBody.tags[0].name.ToString(), Is.EqualTo("string"));
    }

    [Test, Order(3)]
    public void PutPetTest()
    {
        PetModel petModel = new PetModel();
        petModel.id = 9102023;
        petModel.category = new Category(0, "string");
        petModel.name = "Spike";
        petModel.photoUrls = new String[] { "string" };
        petModel.tags = new Tag[] { new Tag(0, "string") };
        petModel.status = "unavaiable";
        String jsonString = JsonConvert.SerializeObject(petModel, Formatting.Indented);
        Console.WriteLine(jsonString);

        var client = new RestClient(BASE_URL);
        var request = new RestRequest("pet", Method.Put);
        request.AddBody(jsonString);

        var response = client.Execute(request);
        var responseBody = JsonConvert.DeserializeObject<dynamic>(response.Content);

        Console.WriteLine(responseBody);

        Assert.That(((int)response.StatusCode), Is.EqualTo(200));
        Assert.That(responseBody.status.ToString(), Is.EqualTo("unavaiable"));
    }

    [Test, Order(4)]
    public void DeletePetTest()
    {
        int petId = 9102023;

        var client = new RestClient(BASE_URL);
        var request = new RestRequest($"pet/{petId}", Method.Delete);
        var response = client.Execute(request);
        var responseBody = JsonConvert.DeserializeObject<dynamic>(response.Content);

        Assert.That((int)response.StatusCode, Is.EqualTo(200));
        Assert.That((int)responseBody.code, Is.EqualTo(200));
        Assert.That(responseBody.message.ToString(), Is.EqualTo(petId.ToString()));
    }
}
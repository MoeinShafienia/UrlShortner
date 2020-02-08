using System;
using Xunit;
using RA;

namespace test
{
    public class UnitTest1
    {
        [Fact]
        public void EmptyGet()
        {
            new RestAssured()
              .Given()
                .Name("Empty Get")
                .Header("content-type", "application/json")
                .Header("accept-Encoding", "utf-8")
              .When()
                .Get("http://localhost:5000/redirect/")
                .Then()
                .TestStatus("Empty Get", r => r == 400)
                .Assert("Empty Get");
        }

        [Fact]
        public void WrongGet()
        {
            new RestAssured()
              .Given()
                .Name("BullshitGet")
                .Header("content-type", "application/json")
                .Header("accept-Encoding", "utf-8")
              .When()
                .Get("http://localhost:5000/redirect/WhatsUpAlibaba")
                .Then()
                .TestStatus("BullshitGet", r => r == 404)
                .Assert("BullshitGet");
        }

        [Fact]
        public void EmptyPost()
        {
        
            new RestAssured()
            .Given()
                .Name("Empty Post")
                .Header("Content-Type", "application/json")
                .Body("")
            .When()
                .Post("http://localhost:5000/urls")
            .Then()
                .TestStatus("Empty Post", r => r == 400)
                .Assert("Empty Post");
        }

        [Fact]
        public void EmptyJSON()
        {
            var body = new {
                LongUrl = "",
                ShortUrl = ""
            };
            new RestAssured()
            .Given()
                .Name("EmptyJSON")
                .Header("Content-Type", "application/json")
                .Body(body)
            .When()
                .Post("http://localhost:5000/urls")
            .Then()
                .TestStatus("EmptyJSON", r => r == 400)
                .Assert("EmptyJSON");
        }

        [Fact]
        public void NotMatchingJSON()
        {
            var body = new {
                something = ""
            };
            new RestAssured()
            .Given()
                .Name("Empty Post")
                .Header("Content-Type", "application/json")
                .Body(body)
            .When()
                .Post("http://localhost:5000/urls")
            .Then()
                .TestStatus("Empty Post", r => r == 400)
                .Assert("Empty Post");
        }
       
        
    }
}

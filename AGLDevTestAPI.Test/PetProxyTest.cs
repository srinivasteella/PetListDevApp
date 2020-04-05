using AGLDevTestAPI.Proxy;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AGLDevTestAPI.Test
{
    public class PetProxyTest
    {
        [Fact]
        public void GetAsyncTest()
        {
            //given
            var sut = new PetProxy();
            //when
            var result = sut.GetAsync("http://agl-developer-test.azurewebsites.net/people.json");
            //then
            Assert.IsAssignableFrom<string>(result.Result);
        }
    }
}

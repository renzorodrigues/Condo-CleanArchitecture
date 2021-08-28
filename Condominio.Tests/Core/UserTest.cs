using System;
using Condominio.Core.Entities;
using FluentAssertions;
using Xunit;

namespace Condominio.Tests.Core
{
    public class UserTest
    {
        [Fact]
        public void TestarUser()
        {
            Action act = () => new User("Renzo");

            act.Should().NotBeNull();
        }
    }
}
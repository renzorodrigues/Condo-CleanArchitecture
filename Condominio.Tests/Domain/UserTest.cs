using System;
using Condominio.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Condominio.Tests.Domain
{
    public class UserTest
    {
        [Fact]
        public void TestarUser()
        {
            Action act = () => new User("Renzo", new Guid());

            act.Should().NotThrow<Exception>();
        }
    }
}
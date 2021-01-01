#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp.Tests
// File Name: InputTests.cs
// 
// Current Data:
// 2021-01-01 10:44 PM
// 
// Creation Date:
// 2021-01-01 8:04 PM

#endregion

using System.Linq;
using AllOverIt.Fixture;
using FluentAssertions;
using MupenSharp.Models;
using Xunit;

namespace MupenSharp.Tests
{
  public class InputTests : AoiFixtureBase
  {
    [Fact]
    public void InputConversionCorrect()
    {
      var bytes = CreateMany<byte>(4).ToArray();
      var input = new InputModel(bytes);

      var convInt = (byte[]) input;

      bytes.Should().Equal(convInt);
      input.Should().BeEquivalentTo((InputModel) convInt);
    }
  }
}
#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenMovieEditor
// Project: MupenSharp.Tests
// File Name: InputTests.cs
// 
// Current Data:
// 2020-05-12 5:11 PM
// 
// Creation Date:
// 2020-05-12 5:08 PM

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
using System.Collections.Generic;
using System.Threading.Tasks;
using Nekoyume.Model.State;
using NineChronicles.Headless.GraphTypes.States;
using Xunit;
using static NineChronicles.Headless.Tests.GraphQLTestUtils;

namespace NineChronicles.Headless.Tests.GraphTypes.States.Models
{
    public class RankingInfoTypeTest
    {
        [Theory]
        [MemberData(nameof(Members))]
        public async Task Query(RankingInfo rankingInfo, object expected)
        {
            const string query = @"
            {
                avatarAddress
                agentAddress
            }";
            var queryResult = await ExecuteQueryAsync<RankingInfoType>(query, source: rankingInfo);
            Assert.Equal(expected, queryResult.Data);
        }

        public static IEnumerable<object[]> Members => new List<object[]>
        {
            new object[]
            {
                new RankingInfo(Fixtures.AvatarStateFX),
                new Dictionary<string, object>
                {
                    ["avatarAddress"] = Fixtures.AvatarAddress.ToString(),
                    ["agentAddress"] = Fixtures.UserAddress.ToString(),
                },
            },
        };

    }
}

using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Repositories;
using System.Text;

namespace BlazorServer.BuilderPatternExample.UnitTests.MoqBases
{
    public static class MockRepos
    {
        public static Mock<TRepo> MockRepo<TRepo, T>(IEnumerable<T> list)
            where TRepo : class, IRepositoryBase<T>
            where T: BaseModel
        {
            var mock = new Mock<TRepo>();

            mock.Setup(x => x.Add(It.IsAny<T>())).Returns((T x) =>
            {
                x.Id = list.Count() + 1;
                list.Append(x);
                return x;
            });

            mock.Setup(x => x.GetBySlug(It.IsAny<string>())).Returns((string x) => { return list.FirstOrDefault(y => y.Slug == x); });

            mock.Setup(x => x.GetById(It.IsAny<int>())).Returns((int x) => { return list.FirstOrDefault(y => y.Id == x); });

            return mock;
        }
    }
}

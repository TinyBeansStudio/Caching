#pragma warning disable IDE0060 // Remove unused parameter

using System.Threading.Tasks;

namespace TinyBeans.Caching.Tests.Dummy {
    internal class DummyClass {
        public DummyPoco ResultMethod() {
            return new DummyPoco() { Property1 = "p1", Property2 = "p2", Property3 = "p3" };
        }

        public DummyPoco ResultMethod(DummyPoco dummyPoco) {
            return new DummyPoco() { Property1 = "p1", Property2 = "p2", Property3 = "p3" };
        }

        public DummyPoco ResultMethod(DummyPoco dummyPoco1, DummyPoco dummyPoco2) {
            return new DummyPoco() { Property1 = "p1", Property2 = "p2", Property3 = "p3" };
        }

        public DummyPoco ResultMethod(DummyPoco dummyPoco1, DummyPoco dummyPoco2, DummyPoco dummyPoco3) {
            return new DummyPoco() { Property1 = "p1", Property2 = "p2", Property3 = "p3" };
        }

        public DummyPoco ResultMethod(DummyPoco dummyPoco1, DummyPoco dummyPoco2, DummyPoco dummyPoco3, DummyPoco dummyPoco4) {
            return new DummyPoco() { Property1 = "p1", Property2 = "p2", Property3 = "p3" };
        }

        public DummyPoco ResultMethod(DummyPoco dummyPoco1, DummyPoco dummyPoco2, DummyPoco dummyPoco3, DummyPoco dummyPoco4, DummyPoco dummyPoco5) {
            return new DummyPoco() { Property1 = "p1", Property2 = "p2", Property3 = "p3" };
        }

        public async Task<DummyPoco> ResultMethodAsync() {
            return await Task.FromResult(new DummyPoco() { Property1 = "p1", Property2 = "p2", Property3 = "p3" });
        }

        public async Task<DummyPoco> ResultMethodAsync(DummyPoco dummyPoco) {
            return await Task.FromResult(new DummyPoco() { Property1 = "p1", Property2 = "p2", Property3 = "p3" });
        }

        public async Task<DummyPoco> ResultMethodAsync(DummyPoco dummyPoco1, DummyPoco dummyPoco2) {
            return await Task.FromResult(new DummyPoco() { Property1 = "p1", Property2 = "p2", Property3 = "p3" });
        }

        public async Task<DummyPoco> ResultMethodAsync(DummyPoco dummyPoco1, DummyPoco dummyPoco2, DummyPoco dummyPoco3) {
            return await Task.FromResult(new DummyPoco() { Property1 = "p1", Property2 = "p2", Property3 = "p3" });
        }

        public async Task<DummyPoco> ResultMethodAsync(DummyPoco dummyPoco1, DummyPoco dummyPoco2, DummyPoco dummyPoco3, DummyPoco dummyPoco4) {
            return await Task.FromResult(new DummyPoco() { Property1 = "p1", Property2 = "p2", Property3 = "p3" });
        }

        public async Task<DummyPoco> ResultMethodAsync(DummyPoco dummyPoco1, DummyPoco dummyPoco2, DummyPoco dummyPoco3, DummyPoco dummyPoco4, DummyPoco dummyPoco5) {
            return await Task.FromResult(new DummyPoco() { Property1 = "p1", Property2 = "p2", Property3 = "p3" });
        }
    }
}
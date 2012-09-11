using Ninject;
using Rhino.Mocks;

namespace Utbildning.App.Core.Tests
{
    public class TestBase<T> where T : class, new()
    {
        T _sut;
        IKernel _kernel;

        protected T SystemUnderTest
        {
            get { return _sut ?? (_sut = Kernel.Get<T>()); }
        }
        protected IKernel Kernel
        {
            get { return _kernel ?? (_kernel = new StandardKernel()); }
        }
        protected TStub Stub<TStub> () where TStub : class
        {
            var stub =  MockRepository.GenerateStub<TStub>();
            Kernel.Bind<TStub>().ToMethod(m => stub);
            return stub;
        }
    }
}
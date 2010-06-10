using System;
using MbUnit.Framework;
using Rhino.Mocks;
using StructureMap.AutoMocking;

namespace Bowling.Specs.Infrastructure
{
	public abstract class concerns
	{
		private Exception ContextSetupException;

		[FixtureSetUp]
		public virtual void main_setup()
		{
			try
			{
				context();
			}
			catch (Exception ex)
			{
				ContextSetupException = ex;
			}
		}

		[SetUp]
		public void context_failure_check()
		{
			if (ContextSetupException != null)
				throw new ContextException(ContextSetupException);
		}

		protected virtual void context()
		{
		}

		[FixtureTearDown]
		public virtual void main_teardown()
		{
			decontext();
		}

		protected virtual void decontext()
		{
		}

		public S stub<S>() where S : class
		{
			return MockRepository.GenerateStub<S>();
		}

		public S stub<S>(params object[] constructorArguments) where S : class
		{
			return MockRepository.GenerateStub<S>(constructorArguments);
		}

		public class ContextException : Exception
		{
			public ContextException(Exception innerException)
				: base("Test failed in Context", innerException)
			{
			}
		}
	}

	public abstract class concerns<T> : concerns where T : class
	{
		private RhinoAutoMocker<T> _amc;

		[FixtureSetUp]
		public override void main_setup()
		{
			_amc = new RhinoAutoMocker<T>();
			base.main_setup();
		}

		[FixtureTearDown]
		public override void main_teardown()
		{
			base.main_teardown();
		}

		public D dependency<D>() where D : class
		{
			return _amc.Get<D>();
		}

		public D inject<D>(D dependency)
		{
			_amc.Inject(dependency);
			return dependency;
		}

		public virtual T build_up()
		{
			var thingBeingTested = _amc.ClassUnderTest;
			return thingBeingTested;
		}
	}
}
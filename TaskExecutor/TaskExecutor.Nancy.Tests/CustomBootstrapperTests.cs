//using System;
//using System.IO;
//using System.Text;
//using Nancy;
//using Nancy.Bootstrapper;
//using Nancy.TinyIoc;
//using NSubstitute;
//using NSubstitute.Extensions;
//using NUnit.Framework;
//using NUnit.Framework.Internal;
 
//namespace TaskExecutor.Nancy.Tests
//{
//    [TestFixture]
//    public class CustomBootstrapperTests
//    {
//        [Test]
//        public void RequestStartup_WhenInvoked_ShouldCallAddItemToEndOfPipeline()
//        {
//            //Arrange
//            var iocContainer = new TinyIoCContainer();
//            var errorPipeline = Substitute.For<ErrorPipeline>();
//            var pipelines = Substitute.For<IPipelines>();
//            pipelines.OnError.Returns(errorPipeline);

//            var context = new NancyContext();

//            var sut = new CustomBootstrapperTestWrapper(configurator => { });
//            //Act
//            sut.RequestStartup(iocContainer, pipelines, context);
//            //Assert
//            errorPipeline.Received(1).AddItemToEndOfPipeline(Arg.Any<Func<NancyContext, Exception, dynamic>>());
//        }

//        [Test]
//        public void RequestStartup_WhenInvoked_ShouldAddErrorHandlingFunc()
//        {
//            //Arrange
//            Func<NancyContext, Exception, dynamic> errorFunc = null;
//            var iocContainer = new TinyIoCContainer();
//            var errorPipeline = Substitute.For<ErrorPipeline>();
//            errorPipeline.AddItemToEndOfPipeline(Arg.Do<Func<NancyContext, Exception, dynamic>>(x => { errorFunc = x; }));

//            var pipelines = Substitute.For<IPipelines>();
//            pipelines.OnError.Returns(errorPipeline);

//            var context = new NancyContext();

//            var sut = new CustomBootstrapperTestWrapper(configurator => { });
//            //Act
//            sut.RequestStartup(iocContainer, pipelines, context);
//            //Assert
//            Assert.IsNotNull(errorFunc);
//        }

//        [Test]
//        public void RequestStartup_WhenInvoked_ShouldAddErrorHandlingFuncToReturnInternalServerErrorWithMessage()
//        {
//            //Arrange
//            var testException = new Exception("an error occured");
//            Func<NancyContext, Exception, dynamic> errorFunc = null;
//            var iocContainer = new TinyIoCContainer();
//            var errorPipeline = Substitute.For<ErrorPipeline>();
//            errorPipeline.AddItemToEndOfPipeline(Arg.Do<Func<NancyContext, Exception, dynamic>>(x => { errorFunc = x; }));

//            var pipelines = Substitute.For<IPipelines>();
//            pipelines.OnError.Returns(errorPipeline);

//            var context = new NancyContext();

//            var sut = new CustomBootstrapperTestWrapper(configurator => { });
//            //Act
//            sut.RequestStartup(iocContainer, pipelines, context);
//            //Assert
//            var expectedErrorMessage = "an error occured";
//            var expectedContentType = "powerShellScript/plain";
//            AssertInternalServerErrorWasReturned(errorFunc, context, testException, expectedContentType, expectedErrorMessage);
//        }

//        private static void AssertInternalServerErrorWasReturned(Func<NancyContext, Exception, dynamic> errorFunc, NancyContext context, Exception testException, string expectedContentType, string expectedErrorMessage)
//        {
//            var response = (Response)errorFunc.Invoke(context, testException);
//            var message = GetMessage(response);
//            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
//            Assert.AreEqual(expectedContentType, response.ContentType);
//            Assert.AreEqual(expectedErrorMessage, message);
//        }

//        private static string GetMessage(Response response)
//        {
//            using (var stream = new MemoryStream())
//            {
//                response.Contents.Invoke(stream);
//                return Encoding.UTF8.GetString(stream.ToArray());
//            }
//        }
//    }
//}
// Uncomment the following to provide samples for PageResult<T>. Must also add the Microsoft.AspNet.WebApi.OData
// package to your project.
////#define Handle_PageResultOfT

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Edutor.Web.Api.Models.NewModels;
using Edutor.Web.Api.Models.ReturnTypes;
using Edutor.Web.Api.Models;
using Edutor.Web.Api.Models.ModModels;
#if Handle_PageResultOfT
using System.Web.Http.OData;
#endif

namespace Edutor.Web.Api.Areas.HelpPage
{
    /// <summary>
    /// Use this class to customize the Help Page.
    /// For example you can set a custom <see cref="System.Web.Http.Description.IDocumentationProvider"/> to supply the documentation
    /// or you can provide the samples for the requests/responses.
    /// </summary>
    public static class HelpPageConfig
    {
        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
            MessageId = "Edutor.Web.Api.Areas.HelpPage.TextSample.#ctor(System.String)",
            Justification = "End users may choose to merge this string with existing localized resources.")]
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
            MessageId = "bsonspec",
            Justification = "Part of a URI.")]
        public static void Register(HttpConfiguration config)
        {
            //// Uncomment the following to use the documentation from XML documentation file.
            config.SetDocumentationProvider(new XmlDocumentationProvider(HttpContext.Current.Server.MapPath("~/bin/Edutor.Api.xml")));

            //// Uncomment the following to use "sample string" as the sample for all actions that have string as the body parameter or return type.
            //// Also, the string arrays will be used for IEnumerable<string>. The sample objects will be serialized into different media type 
            //// formats by the available formatters.
            //config.SetSampleObjects(new Dictionary<Type, object>
            //{
            //    {typeof(string), "sample string"},
            //    {typeof(IEnumerable<string>), new string[]{"sample 1", "sample 2"}},
            //    //{ typeof(New.NewStudent), new New.NewStudent { Name="Fulanito Cosme", Address = "Espa�a", Curp="FEBA911206",Phone="5540", TutorId=1, TutorRelationship="pads" } }
            //});

            config.SetSampleJsonObjects(new Dictionary<Type, string> 
            { 
                {typeof(PagedDataResponse<Group>),"{\"pageCount\":5,\"pageNumber\":2,\"pageSize\":3,\"items\":[{\"groupId\":3,\"name\":\"1U\",\"subject\":\"Ciudad Real\",\"fromDate\":\"2015-02-20T00:00:00\",\"toDate\":null,\"studentsCount\":8,\"teachersCount\":4,\"links\":[{\"rel\":\"self\",\"href\":\"http://api.edutor-tt.com/groups/3\",\"method\":\"GET\"},{\"rel\":\"students\",\"href\":\"http://api.edutor-tt.com/groups/3/students\",\"method\":\"GET\"},{\"rel\":\"schoolusers\",\"href\":\"http://api.edutor-tt.com/groups/3/schoolusers\",\"method\":\"GET\"}]},{\"groupId\":4,\"name\":\"2U\",\"subject\":\"St. John's\",\"fromDate\":\"2015-03-01T00:00:00\",\"toDate\":null,\"studentsCount\":12,\"teachersCount\":2,\"links\":[{\"rel\":\"self\",\"href\":\"http://api.edutor-tt.com/groups/4\",\"method\":\"GET\"},{\"rel\":\"students\",\"href\":\"http://api.edutor-tt.com/groups/4/students\",\"method\":\"GET\"},{\"rel\":\"schoolusers\",\"href\":\"http://api.edutor-tt.com/groups/4/schoolusers\",\"method\":\"GET\"}]},{\"groupId\":5,\"name\":\"3G\",\"subject\":\"Rivire-du-Loup\",\"fromDate\":\"2015-05-05T00:00:00\",\"toDate\":null,\"studentsCount\":6,\"teachersCount\":5,\"links\":[{\"rel\":\"self\",\"href\":\"http://api.edutor-tt.com/groups/5\",\"method\":\"GET\"},{\"rel\":\"students\",\"href\":\"http://api.edutor-tt.com/groups/5/students\",\"method\":\"GET\"},{\"rel\":\"schoolusers\",\"href\":\"http://api.edutor-tt.com/groups/5/schoolusers\",\"method\":\"GET\"}]}],\"links\":[{\"rel\":\"currentPage\",\"href\":\"http://api.edutor-tt.com/groups?pageNumber=2&pageSize=3\",\"method\":\"GET\"},{\"rel\":\"previousPage\",\"href\":\"http://api.edutor-tt.com/groups?pageNumber=1&pageSize=3\",\"method\":\"GET\"},{\"rel\":\"nextPage\",\"href\":\"http://api.edutor-tt.com/groups?pageNumber=3&pageSize=3\",\"method\":\"GET\"}]}"},
                {typeof(Group), "{\"groupId\":15,\"name\":\"3C\",\"subject\":\"Tercero C\",\"fromDate\":\"2015-01-28T00:00:00\",\"toDate\":\"2015-06-28T00:00:00\",\"studentsCount\":0,\"teachersCount\":0,\"links\":[{\"rel\":\"self\",\"href\":\"http://api.edutor-tt.com/groups/15\",\"method\":\"GET\"},{\"rel\":\"students\",\"href\":\"http://api.edutor-tt.com/groups/15/students\",\"method\":\"GET\"},{\"rel\":\"schoolusers\",\"href\":\"http://api.edutor-tt.com/groups/15/schoolusers\",\"method\":\"GET\"}]}"},
                {typeof(NewGroup), "{\"Name\":\"3C\",\"Subject\":\"Tercero C\",\"FromDate\":\"2015-01-28T00:00:00\",\"ToDate\":\"2015-06-28T00:00:00\"}"},
                {typeof(ModifiableGroup), "{\"GroupId\":16,\"Name\":\"5C\",\"Subject\":\"Matematicas I\",\"FromDate\":\"2015-05-26T21:11:07.1523961-05:00\",\"ToDate\":\"2015-09-26T00:00:00-05:00\"}"},
                
                {typeof(PagedDataResponse<Tutor>), "{\"pageCount\":20,\"pageNumber\":3,\"pageSize\":2,\"items\":[{\"job\":\"\",\"jobTelephone\":null,\"userId\":13,\"name\":\"Garrison X. Nash\",\"curp\":\"BRNE382732WUGDRN32\",\"email\":\"Sed@semegetmassa.net\",\"address\":\"P.O. Box 365, 5407 Ultrices Ave\",\"mobile\":\"0462162135\",\"phone\":null,\"type\":\"T\",\"links\":[{\"rel\":\"self\",\"href\":\"http://api.edutor-tt.com/tutors/13\",\"method\":\"GET\"},{\"rel\":\"students\",\"href\":\"http://api.edutor-tt.com/tutors/13/students\",\"method\":\"GET\"}]},{\"job\":\"\",\"jobTelephone\":null,\"userId\":14,\"name\":\"Adena Grant\",\"curp\":\"CEVO852867TJKFYG44\",\"email\":\"justo.eu@dictumProineget.net\",\"address\":\"795-5910 Suscipit, Ave\",\"mobile\":\"0364520293\",\"phone\":null,\"type\":\"T\",\"links\":[{\"rel\":\"self\",\"href\":\"http://api.edutor-tt.com/tutors/14\",\"method\":\"GET\"},{\"rel\":\"students\",\"href\":\"http://api.edutor-tt.com/tutors/14/students\",\"method\":\"GET\"}]}],\"links\":[{\"rel\":\"currentPage\",\"href\":\"http://api.edutor-tt.com/tutors?pageNumber=3&pageSize=2\",\"method\":\"GET\"},{\"rel\":\"previousPage\",\"href\":\"http://api.edutor-tt.com/tutors?pageNumber=2&pageSize=2\",\"method\":\"GET\"},{\"rel\":\"nextPage\",\"href\":\"http://api.edutor-tt.com/tutors?pageNumber=4&pageSize=2\",\"method\":\"GET\"}]}"},
                {typeof(Tutor), "{\"job\":\"�rbitro\",\"jobTelephone\":\"938476263\",\"userId\":2,\"name\":\"Cairo Chaney\",\"curp\":\"ADCV818338LIPFMC29\",\"email\":\"mi.tempor@mifelis.com\",\"address\":\"Ap #388-1548 Neque Ave\",\"mobile\":\"0138346865\",\"phone\":null,\"type\":\"T\",\"links\":[{\"rel\":\"self\",\"href\":\"http://api.edutor-tt.com/tutors/2\",\"method\":\"GET\"},{\"rel\":\"students\",\"href\":\"http://api.edutor-tt.com/tutors/2/students\",\"method\":\"GET\"}]}"},
                {typeof(NewTutor), "{\"Job\":\"Fot�grafo\",\"JobTelephone\":null,\"Name\":\"Antonio Peregrino Bbbola�os\",\"Curp\":\"FEBA911206HDFRLN19\",\"Email\":\"juan@escom.edu\",\"Address\":\"Av. Juan de Dios B�tiz esq. Av. Miguel Oth�n de Mendiz�bal\",\"Mobile\":\"55545869515\",\"Phone\":null}"},
                {typeof(ModifiableTutor), "{\"Job\":\"Fot�grafo\",\"JobTelephone\":null,\"UserId\":14,\"Name\":\"Clementino Bornstein\",\"Email\":\"cleao@bornstein.org.mx.com\",\"Address\":\"Av. Juan de Dios B�tiz esq. Av. Miguel Oth�n de Mendiz�bal\",\"Mobile\":\"5545869515\",\"Phone\":\"5545869515\"}"},
                
                {typeof(PagedDataResponse<SchoolUser>), "{\"pageCount\":31,\"pageNumber\":4,\"pageSize\":2,\"items\":[{\"position\":\"P\",\"userId\":11,\"name\":\"Benedict H. Paul\",\"curp\":\"CIBY457198YTWKRU65\",\"email\":\"diam.Pellentesque@Praesenteunulla.com\",\"address\":\"P.O. Box 377, 1776 Libero. Rd.\",\"mobile\":\"0818980771\",\"phone\":\"2899729854\",\"type\":\"S\",\"links\":[{\"rel\":\"self\",\"href\":\"http://api.edutor-tt.com/schoolusers/11\",\"method\":\"GET\"},{\"rel\":\"groups\",\"href\":\"http://api.edutor-tt.com/schoolusers/11/groups\",\"method\":\"GET\"}]},{\"position\":\"P\",\"userId\":12,\"name\":\"Tobias Q. Moon\",\"curp\":\"DIHO215206MXLITH46\",\"email\":\"eu@est.net\",\"address\":\"3184 Auctor St.\",\"mobile\":\"0497612116\",\"phone\":\"4674424775\",\"type\":\"S\",\"links\":[{\"rel\":\"self\",\"href\":\"http://api.edutor-tt.com/schoolusers/12\",\"method\":\"GET\"},{\"rel\":\"groups\",\"href\":\"http://api.edutor-tt.com/schoolusers/12/groups\",\"method\":\"GET\"}]}],\"links\":[{\"rel\":\"currentPage\",\"href\":\"http://api.edutor-tt.com/schoolusers?pageNumber=4&pageSize=2\",\"method\":\"GET\"},{\"rel\":\"previousPage\",\"href\":\"http://api.edutor-tt.com/schoolusers?pageNumber=3&pageSize=2\",\"method\":\"GET\"},{\"rel\":\"nextPage\",\"href\":\"http://api.edutor-tt.com/schoolusers?pageNumber=5&pageSize=2\",\"method\":\"GET\"}]}"},    
                {typeof(SchoolUser), "{\"position\":\"P\",\"userId\":17,\"name\":\"Whitney G. Ball\",\"curp\":\"DORD624610QZZEVN99\",\"email\":\"ante.blandit.viverra@arcuSedeu.net\",\"address\":\"770-6722 Est St.\",\"mobile\":\"0208353883\",\"phone\":\"1476367123\",\"type\":\"S\",\"links\":[{\"rel\":\"self\",\"href\":\"http://api.edutor-tt.com/schoolusers/17\",\"method\":\"GET\"},{\"rel\":\"groups\",\"href\":\"http://api.edutor-tt.com/schoolusers/17/groups\",\"method\":\"GET\"}]}"},
                {typeof(NewSchoolUser), "{\"Position\":\"A\",\"Name\":\"School S. Magan\",\"Curp\":\"FEBA911206HDFRLN40\",\"Email\":\"ssss@msn.com\",\"Address\":\"Av. Juan de Dios B�tiz esq. Av. Miguel Oth�n de Mendiz�bal\",\"Mobile\":\"5554586951\",\"Phone\":null}"},
                {typeof(ModifiableSchoolUser), "{\"Position\":null,\"UserId\":17,\"Name\":\"Peter Clemenza\",\"Email\":\"cleao@bostein.org.mx.com\",\"Address\":\"Av. Juan de Dios B�tiz esq. Av. Miguel Oth�n de Mendiz�bal\",\"Mobile\":\"5554586951\",\"Phone\":\"5554586951\"}"},
                


                {typeof(PagedDataResponse<Student>), "{\"pageCount\":4,\"pageNumber\":1,\"pageSize\":2,\"items\":[{\"studentId\":1,\"tutorId\":2,\"tutorRelationship\":\"aun\",\"isActive\":false,\"address\":\"Ap #388-1548 Neque Ave\",\"phone\":\"8816363220\",\"curp\":\"EFUN614645IWRYX8GJ\",\"name\":\"Phelan H. Dillard\",\"links\":[{\"rel\":\"self\",\"href\":\"http://api.edutor-tt.com/students/1\",\"method\":\"GET\"},{\"rel\":\"tutor\",\"href\":\"http://api.edutor-tt.com/tutors/2\",\"method\":\"GET\"}]},{\"studentId\":3,\"tutorId\":4,\"tutorRelationship\":\"aun\",\"isActive\":false,\"address\":\"Ap #474-8185 Lobortis Street\",\"phone\":\"6105015383\",\"curp\":\"HGVX569745XWHID1AJ\",\"name\":\"Hope Mayo\",\"links\":[{\"rel\":\"self\",\"href\":\"http://api.edutor-tt.com/students/3\",\"method\":\"GET\"},{\"rel\":\"tutor\",\"href\":\"http://api.edutor-tt.com/tutors/4\",\"method\":\"GET\"}]}],\"links\":[{\"rel\":\"currentPage\",\"href\":\"http://api.edutor-tt.com/groups/3/students?pageNumber=1&pageSize=2\",\"method\":\"GET\"},{\"rel\":\"nextPage\",\"href\":\"http://api.edutor-tt.com/groups/3/students?pageNumber=2&pageSize=2\",\"method\":\"GET\"}]}"},
            });
            

            // Extend the following to provide factories for types not handled automatically (those lacking parameterless
            // constructors) or for which you prefer to use non-default property values. Line below provides a fallback
            // since automatic handling will fail and GeneratePageResult handles only a single type.
#if Handle_PageResultOfT
            config.GetHelpPageSampleGenerator().SampleObjectFactories.Add(GeneratePageResult);
#endif

            // Extend the following to use a preset object directly as the sample for all actions that support a media
            // type, regardless of the body parameter or return type. The lines below avoid display of binary content.
            // The BsonMediaTypeFormatter (if available) is not used to serialize the TextSample object.
            config.SetSampleForMediaType(
                new TextSample("Binary JSON content. See http://bsonspec.org for details."),
                new MediaTypeHeaderValue("application/bson"));

            //// Uncomment the following to use "[0]=foo&[1]=bar" directly as the sample for all actions that support form URL encoded format
            //// and have IEnumerable<string> as the body parameter or return type.
            //config.SetSampleForType("[0]=foo&[1]=bar", new MediaTypeHeaderValue("application/x-www-form-urlencoded"), typeof(IEnumerable<string>));

            //// Uncomment the following to use "1234" directly as the request sample for media type "text/plain" on the controller named "Values"
            //// and action named "Put".
            //config.SetSampleRequest("1234", new MediaTypeHeaderValue("text/plain"), "Values", "Put");

            //// Uncomment the following to use the image on "../images/aspNetHome.png" directly as the response sample for media type "image/png"
            //// on the controller named "Values" and action named "Get" with parameter "id".
            //config.SetSampleResponse(new ImageSample("../images/aspNetHome.png"), new MediaTypeHeaderValue("image/png"), "Values", "Get", "id");

            //// Uncomment the following to correct the sample request when the action expects an HttpRequestMessage with ObjectContent<string>.
            //// The sample will be generated as if the controller named "Values" and action named "Get" were having string as the body parameter.
            //config.SetActualRequestType(typeof(string), "Values", "Get");

            //// Uncomment the following to correct the sample response when the action returns an HttpResponseMessage with ObjectContent<string>.
            //// The sample will be generated as if the controller named "Values" and action named "Post" were returning a string.
            //config.SetActualResponseType(typeof(string), "Values", "Post");
        }

#if Handle_PageResultOfT
        private static object GeneratePageResult(HelpPageSampleGenerator sampleGenerator, Type type)
        {
            if (type.IsGenericType)
            {
                Type openGenericType = type.GetGenericTypeDefinition();
                if (openGenericType == typeof(PageResult<>))
                {
                    // Get the T in PageResult<T>
                    Type[] typeParameters = type.GetGenericArguments();
                    Debug.Assert(typeParameters.Length == 1);

                    // Create an enumeration to pass as the first parameter to the PageResult<T> constuctor
                    Type itemsType = typeof(List<>).MakeGenericType(typeParameters);
                    object items = sampleGenerator.GetSampleObject(itemsType);

                    // Fill in the other information needed to invoke the PageResult<T> constuctor
                    Type[] parameterTypes = new Type[] { itemsType, typeof(Uri), typeof(long?), };
                    object[] parameters = new object[] { items, null, (long)ObjectGenerator.DefaultCollectionSize, };

                    // Call PageResult(IEnumerable<T> items, Uri nextPageLink, long? count) constructor
                    ConstructorInfo constructor = type.GetConstructor(parameterTypes);
                    return constructor.Invoke(parameters);
                }
            }

            return null;
        }
#endif
    }
}
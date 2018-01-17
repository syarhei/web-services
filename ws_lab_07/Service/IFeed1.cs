using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;

namespace Service {
    [ServiceContract]
    [ServiceKnownType(typeof(Atom10FeedFormatter))]
    [ServiceKnownType(typeof(List<Note>))]
    public interface IFeed1 {
        [OperationContract]
        [WebGet(UriTemplate = "students/{studentId}/notes", BodyStyle = WebMessageBodyStyle.Bare)]
        SyndicationFeedFormatter GetStudentNotes(string studentId);
    }
}

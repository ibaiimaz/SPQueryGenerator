using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPQueryGenerator
{
    public class Generator
    {
        const int WHERE_OPEN_TAG_LENGTH = 7;
        const int WHERE_OPEN_CLOSE_TAG_LENGTH = 15;

        private string query = "";

        public string Query
        {
            get { return query; }
        }

        public void AddParam(string field, string value)
        {
            AddParam(field, value, "Text");
        }

        public void AddParam(string field, string value, string type)
        {
            if (IsFirstParam())
                AddParamToQuery(field, value, type);   
            else
                ConcatParamToQuery(field, value, type);
        }

        private void ConcatParamToQuery(string field, string value, string type)
        {
            int length = query.Length;
            string beforeQueryWithoutWhereTag = query.Substring(WHERE_OPEN_TAG_LENGTH, length - WHERE_OPEN_CLOSE_TAG_LENGTH);
            query = "<Where><And>" + beforeQueryWithoutWhereTag + FieldQuerySection(field, value, type) + "</And></Where>";
        }

        private void AddParamToQuery(string field, string value, string type)
        {
            query = "<Where>" + FieldQuerySection(field, value, type) + "</Where>";
        }

        private string FieldQuerySection(string field, string value, string type)
        {
            return string.Format(@"<Eq><FieldRef Name='{0}' /><Value Type='{1}'>{2}</Value></Eq>", field, type, value);
        }

        private bool IsFirstParam()
        {
            return string.IsNullOrEmpty(query);
        }
    }
}

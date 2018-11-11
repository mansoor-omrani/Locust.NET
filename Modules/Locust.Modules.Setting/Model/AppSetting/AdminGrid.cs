using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.BaseInfo;
using Locust.Model;
using Locust.Modules.Setting.Fields.AppSetting;

namespace Locust.Modules.Setting.Model.AppSetting
{
    public class AdminGrid : BaseModel
    {
        private BasicData<Enums.SettingType> _SettingType;
        public BasicData<Enums.SettingType> SettingType
        {
            get
            {
                if (_SettingType == null)
                    _SettingType = new BasicData<Enums.SettingType>();
                return _SettingType;
            }
            set { _SettingType = value; }
        }
        private AppSettingID _AppSettingID;
        public AppSettingID AppSettingID
        {
            get
            {
                if (_AppSettingID == null)
                    _AppSettingID = new AppSettingID();
                return _AppSettingID;
            }
            set { _AppSettingID = value; }
        }
        private Fields.AppSettingCategory.AppSettingCategoryID _AppSettingCategoryID;
        public Fields.AppSettingCategory.AppSettingCategoryID AppSettingCategoryID
        {
            get
            {
                if (_AppSettingCategoryID == null)
                    _AppSettingCategoryID = new Fields.AppSettingCategory.AppSettingCategoryID();
                return _AppSettingCategoryID;
            }
            set { _AppSettingCategoryID = value; }
        }
        private Fields.AppSettingCategory.Title _AppSettingCategoryTitle;
        public Fields.AppSettingCategory.Title AppSettingCategoryTitle
        {
            get
            {
                if (_AppSettingCategoryTitle == null)
                    _AppSettingCategoryTitle = new Fields.AppSettingCategory.Title();
                return _AppSettingCategoryTitle;
            }
            set { _AppSettingCategoryTitle = value; }
        }
        private SettingSize _SettingSize;
        public SettingSize SettingSize
        {
            get
            {
                if (_SettingSize == null)
                    _SettingSize = new SettingSize();
                return _SettingSize;
            }
            set { _SettingSize = value; }
        }
        private Encrypted _Encrypted;
        public Encrypted Encrypted
        {
            get
            {
                if (_Encrypted == null)
                    _Encrypted = new Encrypted();
                return _Encrypted;
            }
            set { _Encrypted = value; }
        }
        private Sensitive _Sensitive;
        public Sensitive Sensitive
        {
            get
            {
                if (_Sensitive == null)
                    _Sensitive = new Sensitive();
                return _Sensitive;
            }
            set { _Sensitive = value; }
        }
        private SettingDir _SettingDir;
        public SettingDir SettingDir
        {
            get
            {
                if (_SettingDir == null)
                    _SettingDir = new SettingDir();
                return _SettingDir;
            }
            set { _SettingDir = value; }
        }
        private Key _Key;
        public Key Key
        {
            get
            {
                if (_Key == null)
                    _Key = new Key();
                return _Key;
            }
            set { _Key = value; }
        }
        private SettingBaseTable _SettingBaseTable;
        public SettingBaseTable SettingBaseTable
        {
            get
            {
                if (_SettingBaseTable == null)
                    _SettingBaseTable = new SettingBaseTable();
                return _SettingBaseTable;
            }
            set { _SettingBaseTable = value; }
        }
        private Fields.AppSetting.Title _Title;
        public Fields.AppSetting.Title Title
        {
            get
            {
                if (_Title == null)
                    _Title = new Fields.AppSetting.Title();
                return _Title;
            }
            set { _Title = value; }
        }
        private Value _Value;
        public Value Value
        {
            get
            {
                if (_Value == null)
                    _Value = new Value();
                return _Value;
            }
            set { _Value = value; }
        }
        private Fields.AppSetting.Description _Description;
        public Fields.AppSetting.Description Description
        {
            get
            {
                if (_Description == null)
                    _Description = new Fields.AppSetting.Description();
                return _Description;
            }
            set { _Description = value; }
        }
        private SettingValues _SettingValues;
        public SettingValues SettingValues
        {
            get
            {
                if (_SettingValues == null)
                    _SettingValues = new SettingValues();
                return _SettingValues;
            }
            set { _SettingValues = value; }
        }
        protected override IEnumerable<KeyValuePair<string, object>> GetProperties()
        {
            var result = new List<KeyValuePair<string, object>>();

            result.Add(new KeyValuePair<string, object>("SettingType", SettingType.Value));
            result.Add(new KeyValuePair<string, object>("Id", AppSettingID.Value));
            result.Add(new KeyValuePair<string, object>("AppSettingCategoryId", AppSettingCategoryID.Value));
            result.Add(new KeyValuePair<string, object>("AppSettingCategoryTitle", AppSettingCategoryTitle.Value));
            result.Add(new KeyValuePair<string, object>("SettingSize", SettingSize.Value));
            result.Add(new KeyValuePair<string, object>("Encrypted", Encrypted.Value));
            result.Add(new KeyValuePair<string, object>("Sensitive", Sensitive.Value));
            result.Add(new KeyValuePair<string, object>("SettingDir", SettingDir.Value));
            result.Add(new KeyValuePair<string, object>("Key", Key.Value));
            result.Add(new KeyValuePair<string, object>("SettingBaseTable", SettingBaseTable.Value));
            result.Add(new KeyValuePair<string, object>("Title", Title.Value));
            result.Add(new KeyValuePair<string, object>("Value", Value.Value));
            result.Add(new KeyValuePair<string, object>("Description", Description.Value));
            result.Add(new KeyValuePair<string, object>("SettingValues", SettingValues.Value));

            return result;
        }
    }
}

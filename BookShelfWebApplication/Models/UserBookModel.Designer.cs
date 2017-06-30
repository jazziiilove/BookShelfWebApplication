﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("BookShelfWebModel1", "FK_Book_User", "User", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(BookShelfWebApplication.Models.User), "Book", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(BookShelfWebApplication.Models.Book), true)]

#endregion

namespace BookShelfWebApplication.Models
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class BookShelfWebEntities1 : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new BookShelfWebEntities1 object using the connection string found in the 'BookShelfWebEntities1' section of the application configuration file.
        /// </summary>
        public BookShelfWebEntities1() : base("name=BookShelfWebEntities1", "BookShelfWebEntities1")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new BookShelfWebEntities1 object.
        /// </summary>
        public BookShelfWebEntities1(string connectionString) : base(connectionString, "BookShelfWebEntities1")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new BookShelfWebEntities1 object.
        /// </summary>
        public BookShelfWebEntities1(EntityConnection connection) : base(connection, "BookShelfWebEntities1")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Book> Books
        {
            get
            {
                if ((_Books == null))
                {
                    _Books = base.CreateObjectSet<Book>("Books");
                }
                return _Books;
            }
        }
        private ObjectSet<Book> _Books;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<User> Users
        {
            get
            {
                if ((_Users == null))
                {
                    _Users = base.CreateObjectSet<User>("Users");
                }
                return _Users;
            }
        }
        private ObjectSet<User> _Users;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Books EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToBooks(Book book)
        {
            base.AddObject("Books", book);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Users EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToUsers(User user)
        {
            base.AddObject("Users", user);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="BookShelfWebModel1", Name="Book")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Book : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Book object.
        /// </summary>
        /// <param name="bookID">Initial value of the bookID property.</param>
        /// <param name="bookStatus">Initial value of the bookStatus property.</param>
        public static Book CreateBook(global::System.Int32 bookID, global::System.Int32 bookStatus)
        {
            Book book = new Book();
            book.bookID = bookID;
            book.bookStatus = bookStatus;
            return book;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 bookID
        {
            get
            {
                return _bookID;
            }
            set
            {
                if (_bookID != value)
                {
                    OnbookIDChanging(value);
                    ReportPropertyChanging("bookID");
                    _bookID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("bookID");
                    OnbookIDChanged();
                }
            }
        }
        private global::System.Int32 _bookID;
        partial void OnbookIDChanging(global::System.Int32 value);
        partial void OnbookIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String isbn
        {
            get
            {
                return _isbn;
            }
            set
            {
                OnisbnChanging(value);
                ReportPropertyChanging("isbn");
                _isbn = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("isbn");
                OnisbnChanged();
            }
        }
        private global::System.String _isbn;
        partial void OnisbnChanging(global::System.String value);
        partial void OnisbnChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String bookName
        {
            get
            {
                return _bookName;
            }
            set
            {
                OnbookNameChanging(value);
                ReportPropertyChanging("bookName");
                _bookName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("bookName");
                OnbookNameChanged();
            }
        }
        private global::System.String _bookName;
        partial void OnbookNameChanging(global::System.String value);
        partial void OnbookNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String authorName
        {
            get
            {
                return _authorName;
            }
            set
            {
                OnauthorNameChanging(value);
                ReportPropertyChanging("authorName");
                _authorName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("authorName");
                OnauthorNameChanged();
            }
        }
        private global::System.String _authorName;
        partial void OnauthorNameChanging(global::System.String value);
        partial void OnauthorNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> userID
        {
            get
            {
                return _userID;
            }
            set
            {
                OnuserIDChanging(value);
                ReportPropertyChanging("userID");
                _userID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("userID");
                OnuserIDChanged();
            }
        }
        private Nullable<global::System.Int32> _userID;
        partial void OnuserIDChanging(Nullable<global::System.Int32> value);
        partial void OnuserIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 bookStatus
        {
            get
            {
                return _bookStatus;
            }
            set
            {
                OnbookStatusChanging(value);
                ReportPropertyChanging("bookStatus");
                _bookStatus = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("bookStatus");
                OnbookStatusChanged();
            }
        }
        private global::System.Int32 _bookStatus;
        partial void OnbookStatusChanging(global::System.Int32 value);
        partial void OnbookStatusChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BookShelfWebModel1", "FK_Book_User", "User")]
        public User User
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("BookShelfWebModel1.FK_Book_User", "User").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("BookShelfWebModel1.FK_Book_User", "User").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<User> UserReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("BookShelfWebModel1.FK_Book_User", "User");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<User>("BookShelfWebModel1.FK_Book_User", "User", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="BookShelfWebModel1", Name="User")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class User : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new User object.
        /// </summary>
        /// <param name="userID">Initial value of the userID property.</param>
        public static User CreateUser(global::System.Int32 userID)
        {
            User user = new User();
            user.userID = userID;
            return user;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 userID
        {
            get
            {
                return _userID;
            }
            set
            {
                if (_userID != value)
                {
                    OnuserIDChanging(value);
                    ReportPropertyChanging("userID");
                    _userID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("userID");
                    OnuserIDChanged();
                }
            }
        }
        private global::System.Int32 _userID;
        partial void OnuserIDChanging(global::System.Int32 value);
        partial void OnuserIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String fullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                OnfullNameChanging(value);
                ReportPropertyChanging("fullName");
                _fullName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("fullName");
                OnfullNameChanged();
            }
        }
        private global::System.String _fullName;
        partial void OnfullNameChanging(global::System.String value);
        partial void OnfullNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String password
        {
            get
            {
                return _password;
            }
            set
            {
                OnpasswordChanging(value);
                ReportPropertyChanging("password");
                _password = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("password");
                OnpasswordChanged();
            }
        }
        private global::System.String _password;
        partial void OnpasswordChanging(global::System.String value);
        partial void OnpasswordChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String email
        {
            get
            {
                return _email;
            }
            set
            {
                OnemailChanging(value);
                ReportPropertyChanging("email");
                _email = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("email");
                OnemailChanged();
            }
        }
        private global::System.String _email;
        partial void OnemailChanging(global::System.String value);
        partial void OnemailChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String address
        {
            get
            {
                return _address;
            }
            set
            {
                OnaddressChanging(value);
                ReportPropertyChanging("address");
                _address = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("address");
                OnaddressChanged();
            }
        }
        private global::System.String _address;
        partial void OnaddressChanging(global::System.String value);
        partial void OnaddressChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String city
        {
            get
            {
                return _city;
            }
            set
            {
                OncityChanging(value);
                ReportPropertyChanging("city");
                _city = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("city");
                OncityChanged();
            }
        }
        private global::System.String _city;
        partial void OncityChanging(global::System.String value);
        partial void OncityChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BookShelfWebModel1", "FK_Book_User", "Book")]
        public EntityCollection<Book> Books
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Book>("BookShelfWebModel1.FK_Book_User", "Book");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Book>("BookShelfWebModel1.FK_Book_User", "Book", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}

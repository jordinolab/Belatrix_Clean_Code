using CleanCode._12_FullRefactoring;
using CleanCode._12_FullRefactoring.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI.WebControls;

namespace Project.UserControls
{
    public class PostControl : System.Web.UI.UserControl
    {
        
        private readonly PostValidator _validator;
        private readonly PostEntityRepository _repository;

        public PostControl()
        {
            _validator = new PostValidator();
            _repository = new PostEntityRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Page.IsPostBack)
            {
                TrySavePostEntity();
            }
            else
            {
                DisplayForm();
            }
        }

        private PostEntity GetPostEntity()
        {
            return new PostEntity()
            {
                Id = Convert.ToInt32(PostId.Value),
                Title = PostTitle.Text.Trim(),
                Body = PostBody.Text.Trim()
            };
        }

        private void TrySavePostEntity()
        {
            PostEntity entity = GetPostEntity();
            ValidationResult results = _validator.Validate(entity);

            if (results.IsValid)
                _repository.SaveChanges(entity);
            else
                DisplayErrors(results);
        }

        private void DisplayForm()
        {
            PostEntity entity = _repository.GetPostEntity(Convert.ToInt32(Request.QueryString["id"]));
            PostBody.Text = entity.Body;
            PostTitle.Text = entity.Title;
        }

        private void DisplayErrors(ValidationResult results)
        {
            BulletedList summary = (BulletedList)FindControl("ErrorSummary");
            
            foreach (var failure in results.Errors)
            {
                Label errorMessage = FindControl(failure.PropertyName + "Error") as Label;

                if (errorMessage == null)
                    summary.Items.Add(new ListItem(failure.ErrorMessage));
                else
                    errorMessage.Text = failure.ErrorMessage;
            }
        }

        public Label PostBody { get; set; }

        public Label PostTitle { get; set; }

        public int? PostId { get; set; }
    }

    #region helpers

    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public IEnumerable<ValidationError> Errors { get; set; }
    }

    public class ValidationError
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class PostValidator
    {
        public ValidationResult Validate(PostEntity entity)
        {
            throw new NotImplementedException();
        }
    }
    
    #endregion

}
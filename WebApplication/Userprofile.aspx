<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="Userprofile.aspx.cs" Inherits="WebApplication.Userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.13.1/css/all.min.css" integrity="sha256-2XFplPlrFClt0bIdPgpz8H7ojnk10H69xRqd9+uTShA=" crossorigin="anonymous" />
	  <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
	 <section class="home-section">
<div class="container">
<div class="row">
		<div class="col-12">
			<!-- Page title -->
			<div class="my-5">
				<h3>My Profile</h3>
				<hr>
			</div>


			<!-- Personal information START -->
 				<div class="row mb-5 gx-5">
					<!-- Contact detail -->
  				   <h4 class="">Contact detail</h4>
								 
							<div class="row g-3">
								<!-- Username -->
								<div class="col-md-12">
									<label for="inputEmail4" class="form-label">Username*</label>
									<input type="text" runat="server" id="username" readonly="readonly" class="form-control textbox">
								</div>
  								<!-- First Name -->
								<div class="col-md-6">
									<br />
									<label class="form-label">First Name</label>
									<input type="text" runat="server" id="firstName" class="form-control textbox" aria-label="First name">
								</div>
								<!-- Last name -->
								<div class="col-md-6">
									<br />
									<label class="form-label">Last Name</label>
									<input type="text" runat="server" id="lastName" class="form-control textbox" aria-label="Last name" >
								</div>
								<!-- Data of birth -->
								<div class="col-md-6">
									<br />
									<label class="form-label">Data of birth</label>
									<input type="date" runat="server" id="dateOfBirth" class="form-control textbox"  aria-label="Data of birth">
								</div>
								<!-- Email -->
								<div class="col-md-6">
									<br />
									<label class="form-label">Email</label>
									<input type="email" runat="server" id="email" class="form-control textbox" aria-label="Email">
								</div>

								<!-- Current password -->
								<div class="col-md-6">
									<br />
									<label class="form-label">Old password*</label>
									<input readonly="readonly" id="currentPassword" runat="server" type="text" class="form-control textbox" aria-label="Current password">
								</div>

								<!-- New password -->
								<div class="col-md-6">
									<br />
									<label class="form-label">New password</label>
									<input type="password" required="required" id="newPassword" runat="server" class="form-control textbox" placeholder="Your new password" aria-label="Password">
								</div>


								<div class="col-md-6">
									<br />
									<label class="form-label">* Fields that can not be changed!</label>
									 
								</div>

   							</div> <!-- Row END -->
						 
					 
					 
					 
				</div> 
			<!-- Personal information END -->
			 
 		    <!--Div 2 start -->
				<div class="row mb-5 gx-5">
 					 
				</div> 
			<!-- Div 2 end -->

			

				<!-- button -->
				<div class="gap-3 d-md-flex justify-content-md-start text-center">
					 
					<button type="button" runat="server" id="updateProfile_btn" class="btn btn-primary btn-lg">Update profile</button>
				</div>
			 
			
		</div>
	</div>
	</div>

		 </section>
</asp:Content>

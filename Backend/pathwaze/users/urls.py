from django.contrib import admin
from django.urls import path, include
# from rest_framework_simplejwt.views import TokenRefreshView
from . import views
# from .views import RegisterView, LoginView
from .views import LoginView, RegisterView

urlpatterns = [
    path('token/', LoginView.as_view(), name ='token_obtain_pair'),
    # path('token/refresh/', TokenRefreshView.as_view(), name ='token_refresh'),
    # path('logout/', views.LogoutView.as_view(), name='logout'),
    path('register/', RegisterView.as_view(), name='register'),
    path('user/<int:user_id>', views.User.as_view(), name='user'),
]
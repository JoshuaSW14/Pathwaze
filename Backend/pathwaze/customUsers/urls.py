from django.contrib import admin
from django.urls import path, include
from . import views
from .views import RegisterView
# from .views import LoginView, ShoeModel

urlpatterns = [
    # path('token/', LoginView.as_view(), name ='token_obtain_pair'),
    # path('logout/', views.LogoutView.as_view(), name='logout'),
    path('register/', RegisterView.as_view(), name='register'),
    path('user/<int:user_id>', views.User.as_view(), name='user'),
]
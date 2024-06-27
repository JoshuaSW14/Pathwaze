from django.contrib import admin
from django.urls import path, include
from . import views
from .views import RoleView, RoleUsersView

urlpatterns = [
    path('', RoleView.as_view()),
    path('<int:key>', RoleView.as_view()),
    path('<int:role_key>/customUsers/<int:customUser_key>', RoleUsersView.as_view()),
]

from django.contrib.auth.models import AbstractBaseUser, BaseUserManager, PermissionsMixin
from django.db import models
import uuid

class UserManager(BaseUserManager):
    def create_user(self, email, password=None, **extra_fields):
        if not email:
            raise ValueError(_('Email must be set'))
        email = self.normalize_email(email)
        user = self.model(email=email, **extra_fields)

        user.save(using=self._db)
        return user
    def get_by_natural_key(self, email):
        return self.get(email=email)

def generate_uuid():
    return str(uuid.uuid4())

class User(AbstractBaseUser, PermissionsMixin):
    objects = UserManager()

    id = models.CharField(max_length=36, unique=True, primary_key=True, editable=False, default=generate_uuid, serialize=False, verbose_name='ID')
    first_name = models.CharField(max_length=100, default="")
    last_name = models.CharField(max_length=100, default="")
    email = models.EmailField(unique=True)
    phone = models.CharField(max_length=20, unique=False, default="")
    last_login = models.DateTimeField(auto_now=True)
    password = models.CharField(max_length=128)
    is_delete = models.BooleanField(default=False)
    creation_date = models.DateTimeField(auto_now_add=True)
    updated_date = models.DateTimeField(auto_now=True)

    EMAIL_FIELD = 'email'
    USERNAME_FIELD = 'email'

    REQUIRED_FIELDS = []

    def __str__(self):
        return self.email

    def set_password(self, raw_password: str | None) -> None:
        return super().set_password(raw_password)

    class Meta:
        verbose_name = 'user'
        verbose_name_plural = 'users'
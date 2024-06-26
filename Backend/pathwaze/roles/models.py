from django.db import models

admin_permissions = {
    'role': ['add', 'change', 'delete', 'view'],
}

default_user_permissions = {
    'role': ['view'],
}

# Create your models here.
class Role(models.Model):
    id = models.CharField(max_length=36, unique=True, primary_key=True, editable=False, default=generate_uuid, serialize=False, verbose_name='ID')
    name = models.CharField(max_length=100, default="")
    permissions = models.CharField(max_length=100, default="")
    creation_date = models.DateTimeField(auto_now_add=True)
    updated_date = models.DateTimeField(auto_now=True)
    is_deleted = models.BooleanField(default=False)

    def __str__(self):
        return self.name

    class Meta:
        verbose_name = 'role'
        verbose_name_plural = 'roles'
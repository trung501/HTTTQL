from django.db import models
from django.contrib.auth.models import AbstractUser
# Create your models here.
class User(AbstractUser):
    username = models.CharField(max_length=255,unique=True)
    password= models.CharField(max_length=255)
    personID= models.CharField(max_length=20, blank=True, null=True)
    roleID = models.IntegerField(blank=True,default=0, null=True)

    USERNAME_FIELD= 'username'
    REQUIRED_FIELDS=[]
    def __str__(self):
        return self.username
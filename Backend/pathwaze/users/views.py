from rest_framework.views import APIView
from rest_framework.response import Response
from django.contrib.auth import authenticate

from rest_framework import status
from rest_framework import serializers
from users.models import User as UserRequest

class UserSerializer(serializers.ModelSerializer):

    class Meta:
        model = UserRequest
        fields = ('email', 'password', 'first_name', 'last_name')
        extra_kwargs = {'password': {'write_only': True}}

    def create(self, validated_data):
        password = validated_data.pop('password')
        user = UserRequest(**validated_data)
        user.set_password(password)
        user.save()

        return user

class RegisterView(APIView):
    def post(self, request, *args, **kwargs):
        print("POST REQUEST - USERS")
        serializer = UserSerializer(data=request.data)
        if serializer.is_valid():
            user = serializer.save()
            serialized_data = UserSerializer(user).data
            return Response(serialized_data, status=status.HTTP_201_CREATED)
        return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)

class User(APIView):
    def get(self, request, user_id):
        try:
            user = UserRequest.objects.get(id=user_id)
            serializer = UserSerializer(user)

            return Response(serializer.data, status=status.HTTP_200_OK)
        except UserRequest.DoesNotExist:
            return Response({'error': 'User not found'}, status=status.HTTP_404_NOT_FOUND)
        except Exception as e:
            print(e)
            return Response({'error': str(e)}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)
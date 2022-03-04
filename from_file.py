import random



Level = input("Chose advance level:")

list1 = []
list2 = []
list3 = []
i=0
with open("Words.txt","r") as f:
    for line in f:
        list1.extend(line.split())


# while i < 8:
#     list2.append(random.choice(list1))
#     i+=1
# list3 = list2.copy()
# list3.extend(list2)
# print(list3)

while i < 4:
    list2.append(random.choice(list1))
    i+=1
list3 = list2.copy()
list3.extend(list2)
print(list3)
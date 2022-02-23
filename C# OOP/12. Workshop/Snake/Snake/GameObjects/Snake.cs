using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake.GameObjects
{
    public class Snake
    {
        private const char SnakeSymbol = '\u25CF';

        private Queue<Point> snakeElements;

        private int foodIndex = 0;

        private readonly Food[] foods;
        private readonly Wall wall;

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.foods = new Food[]
            {
                new FoodAsteriks(this.wall),
                new FoodDollar(this.wall),
                new FoodHash(this.wall),
            };

            this.CreateSnake();
        }

        public bool TryMove(Point point)
        {
            Point snakeHead = this.snakeElements.Last();

            int nextLeftX = snakeHead.LeftX + point.LeftX;
            int nextTopY = snakeHead.TopY + point.TopY;

            bool isSnake = this.snakeElements
                .Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);

            if (isSnake)
            {
                return false;
            }

            bool isWall = nextLeftX < 0 ||
            nextTopY < 0 ||
            nextLeftX >= this.wall.LeftX ||
            nextTopY >= this.wall.TopY;

            if (isWall)
            {
                return false;
            }

            bool isFood = this.foods[foodIndex].LeftX == nextLeftX &&
                this.foods[foodIndex].TopY == nextTopY;

            if (isFood)
            {
                this.Eat(nextLeftX, nextTopY);
            }

            Point snakePoint = new Point(nextLeftX, nextTopY);

            this.snakeElements.Enqueue(snakePoint);

            snakePoint.Draw(SnakeSymbol);

            Point lastPoint = this.snakeElements.Dequeue();

            lastPoint.Draw(' ');

            return true;
        }

        private void Eat(int nextLeftX, int nextTopY)
        {
            Food food = this.foods[this.foodIndex];

            for (int i = 0; i < food.Points; i++)
            {
                this.snakeElements.Enqueue(new Point(nextLeftX, nextTopY));
            }

            this.foodIndex = GetRandomIndex();

            this.foods[this.foodIndex].SetRandomPosition(this.snakeElements);
        }

        private void CreateSnake()
        {
            this.snakeElements = new Queue<Point>();

            for (int i = 1; i <= 6; i++)
            {
                Point point = new Point(i, 1);

                snakeElements.Enqueue(point);

                point.Draw(SnakeSymbol);
            }

            this.foodIndex = GetRandomIndex();

            this.foods[foodIndex].SetRandomPosition(this.snakeElements);
        }

        private int GetRandomIndex()
            => new Random().Next(0, this.foods.Length);
    }
}

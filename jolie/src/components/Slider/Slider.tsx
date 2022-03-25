import React, { useEffect, useState } from 'react';

import classes from './Slider.module.scss';

interface Props {
	data: string[];
	time?: number;
	delay?: number;
	className?: string;
}

const Slider: React.FC<Props> = ({ data, time = 6, delay = 0, className }) => {
	const [started, setStarted] = useState<boolean>(!delay);
	const [current, setCurrent] = useState<number>(0);

	useEffect(() => {
		let timeout: NodeJS.Timeout;

		if (delay !== 0) {
			timeout = setTimeout(() => {
				setStarted(true);
				setCurrent(current + 1);
			}, delay * 1000);
		}

		return () => clearTimeout(timeout);
	}, []);

	useEffect(() => {
		if (!started) return;

		const interval = setInterval(() => {
			updateSlide();
		}, time * 1000);

		return () => clearInterval(interval);
	}, [current]);

	const updateSlide = () => {
		if (!started) {
			setStarted(true);
		}

		if (current === data.length - 1) {
			setCurrent(0);

			return;
		}

		setCurrent(current + 1);
	};

	return (
		<div className={[classes.Holder, className].join(' ')}>
			{data.map((image, index) => (
				<img
					className={[classes.Image, current === index ? classes.Active : ''].join(' ')}
					src={image}
					alt='screenshot'
					key={index}
				/>
			))}
		</div>
	);
};

export default Slider;
